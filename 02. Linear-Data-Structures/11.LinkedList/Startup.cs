//Implement the data structure linked list.
//Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
//Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).

namespace _11.LinkedList
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var list = new LinkedList<int>();

            var firstElement = new ListItem<int> { Value = 1 };
            var secondElement = new ListItem<int> { Value = 2 };
            var thirdElement = new ListItem<int> { Value = 3 };
            var fourthElement = new ListItem<int> { Value = 4 };

            thirdElement.NextItem = fourthElement;
            secondElement.NextItem = thirdElement;
            firstElement.NextItem = secondElement;
            list.FirstElement = firstElement;

            // traversing the list
            Console.WriteLine("Elements of the list: ");
            var element = list.FirstElement;
            Console.Write("{0}", element.Value);

            while (element.NextItem != null)
            {
                element = element.NextItem;
                Console.Write("-{0}", element.Value);
            }

            Console.WriteLine();
        }
    }
}
