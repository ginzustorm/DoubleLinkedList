using DoubleLinkedList;

DLinkedList<int> myList = new DLinkedList<int>();

myList.Add(1);
myList.Add(2);
myList.Add(3);
myList.Add(4);
myList.Add(5);
myList.Add(6);

myList.PrintList();
Console.WriteLine();
myList.ReversePrintList();

Console.WriteLine("Тест foreach");

foreach(var item in myList)
{
    Console.WriteLine(item);
}

Console.WriteLine();

myList.IsInList(2);
myList.IsInList(10);
myList.Remove(111);
myList.Remove(4);
myList.PrintList();

