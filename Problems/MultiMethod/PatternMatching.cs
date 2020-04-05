using System.Collections.Generic;
using System.Linq;

namespace Problems.MultiMethod
{
    public class State
    {
        public readonly char C;
        public bool HasSelfLoop = false;
        public readonly Dictionary<char, State> NextStates;

        public State(char c)
        {
            C = c;
            NextStates = new Dictionary<char, State>();
        }

        public void AddNextState(State s)
        {
            NextStates.Add(s.C, s);
        }
    }

    public class StateMachine
    {
        private readonly State _startState = new State('$');
        private const char AnyChar = '.';
        private const char RepeatChar = '*';

        public StateMachine(string pattern)
        {
            var prevState = _startState;
            
            foreach(var c in pattern){
                if(c==RepeatChar)
                {
                    prevState.HasSelfLoop = true;
                    continue;
                }
                var state = new State(c);
                prevState.AddNextState(state);
                prevState = state;
            }
        }

        public bool IsMatch(string s)
        {
            if (string.IsNullOrEmpty(s)) return AreAllStatesRepeats();
            
            var state = _startState;
            char lastChar = ' ';
            //use a stack to enable backtracking
            var charStack = new Stack<char>(s.Reverse());
            
            while(charStack.Count != 0)
            {
                var c = charStack.Pop();
                if (lastChar == c) //something is being repeated > 0 times
                {
                    if (!state.HasSelfLoop
                     && !state.NextStates.ContainsKey(AnyChar)) return false;
                    continue;
                }
                lastChar = c;
                if (state.NextStates.ContainsKey(c))
                {
                    state = state.NextStates[c];
                    continue;
                }

                if (state.NextStates.ContainsKey('.'))
                {
                    state = state.NextStates['.'];
                    continue;
                }
                //skip over state/char that repeats 0 times
                foreach (var (_,nextState) in state.NextStates)
                {
                    if (!nextState.HasSelfLoop) continue;
                    state = nextState;
                    break;
                }
                //skipping over a state that repeats 0 times
                if (state.HasSelfLoop)
                {
                    charStack.Push(c);//c hasn't been consumed
                    lastChar = ' ';
                    continue;
                }
                
                return false;
            }
            //make sure the last state has been reached
            return IsFinalState(state);
        }

        private bool AreAllStatesRepeats()
        {
            var queue = new Queue<State>();
            queue.Enqueue(_startState);
            return false;
        }

        private bool IsFinalState(State state)
        {
            //the final state either has a self loop (due to *) or no next states
            if(state.NextStates.Count > 1) return false;
            if(state.NextStates.Count == 0) return true;
            return state.C == state.NextStates.First().Key;
        }
    }

    public class PatternMatching
    {
        //https://leetcode.com/problems/regular-expression-matching/
        public bool IsMatch(string s, string p)
        {
            var sm = new StateMachine(p);
            return sm.IsMatch(s);
        }
    }
}