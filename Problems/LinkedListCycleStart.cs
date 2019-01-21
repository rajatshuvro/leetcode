using DataStructures;

namespace Problems
{
    // https://leetcode.com/problems/linked-list-cycle-ii/description/
    public class LinkedListCycleStart
    {
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;

            var cycleLength = GetCycleLength(head);
            if (cycleLength < 0) return null;

            return GetCycleStart(head, cycleLength);
        }

        private ListNode GetCycleStart(ListNode head, int cycleLength)
        {
            var cycleHead = head;
            var cycleTail = head;
            while (cycleLength > 0)
            {
                cycleTail = cycleTail.next;
                cycleLength--;
            }

            while (cycleHead != cycleTail)
            {
                cycleHead = cycleHead.next;
                cycleTail = cycleTail.next;
            }

            return cycleHead;
        }

        private int GetCycleLength(ListNode head)
        {
            var singleStepper = head;
            int singleCount = 0;
            var doubleStepper = head.next;
            int doubleCount = 1;

            do
            {
                if (doubleStepper == null) return -1;
                if (doubleCount % 2 == 0)
                {
                    singleStepper = singleStepper.next;
                    singleCount++;
                }

                doubleStepper = doubleStepper.next;
                doubleCount++;
                
            } while (singleStepper != doubleStepper);
            //the two steppers have met. 
            return doubleCount - singleCount;
        }
    }
}