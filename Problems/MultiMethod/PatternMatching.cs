using System.Collections.Generic;
using System.Linq;

namespace Problems.MultiMethod
{
    public class State
    {
        public readonly char C;
        public bool HasSelfLoop;
        public State Next;

        public State(char c)
        {
            C = c;
        }
    }

    public class StateMachine
    {
        private readonly State _startState = new State('$');
        private const char AnyChar = '.';
        private const char RepeatChar = '*';

        public StateMachine(string pattern)
        {
            //create the most parsimonious state machine. e.g. a*a => a*
            var prevState = _startState;
            
            foreach(var c in pattern){
                if(c==RepeatChar)
                {
                    prevState.HasSelfLoop = true;
                    continue;
                }
                //compressing multiple chars into one state if subsequent chars are the same
                // but not '.'
                if( prevState.C != AnyChar && c == prevState.C && prevState.HasSelfLoop){
                    continue;
                }
                var state = new State(c);
                prevState.Next =state;
                prevState = state;
            }
        }

        public bool IsMatch(string s)
        {
            if (string.IsNullOrEmpty(s)) return AreAllStatesRepeats();
            
            var state = _startState;
            char prevChar = ' ';
            //use a stack to enable backtracking
            var charStack = new Stack<char>(s.Reverse());
            
            while(charStack.Count != 0)
            {
                var c = charStack.Pop();
                if (prevChar == c && state.HasSelfLoop) //something is being repeated > 0 times
                {
                    continue;
                }

                state = state.Next;
                if (state == null) return false;
                
                prevChar = c;
                if (state.C ==c || state.C == AnyChar)
                {
                    continue;
                }

                //skip over state/char that repeats 0 times
                if (state.HasSelfLoop)
                {
                    charStack.Push(c);//c hasn't been consumed
                    prevChar = ' ';
                    continue;
                }
                
                return false;
            }
            //make sure the last state has been reached
            return state.Next==null && charStack.Count==0;
        }

        private bool AreAllStatesRepeats()
        {
            var state = _startState.Next;
            while (state.Next!=null)
            {
                if (!state.HasSelfLoop) return false;
            }

            return true;
        }
    }

    public class PatternMatching
    {
        //https://leetcode.com/problems/regular-expression-matching/
        public bool IsMatch(string s, string p)
        {
            //special stupid case handling
            if (p == ".*") return true;
            var sm = new StateMachine(p);
            return sm.IsMatch(s);
        }
    }
}