# System.Array

## System.Array

### Methods

| Method                                            | Description                        |
| ------------------------------------------------- | ---------------------------------- |
| `ClearAll()`                                      | 全部清除                           |
| `ContainsIndex(int index)`                        | 是否包含索引                       |
| `Sort()`                                          | 排序                               |
| `Sort(IComparer comparer)`                        | 排序                               |
| `Sort(int index, int length)`                     | 排序                               |
| `Sort(int index, int length, IComparer comparer)` | 排序                               |
| `Reverse()`                                       | 反转                               |
| `Reverse(int index, int length)`                  | 反转                               |
| `Find(Predicate<T> match)`                        | 返回数组中的第一个匹配元素         |
| `FindLast(Predicate<T> match)`                    | 返回数组中的最后一个匹配元素       |
| `FindAll(Predicate<T> match)`                     | 返回数组中所有匹配的元素           |
| `FindIndex(Predicate<T> match)`                   | 返回数组中的第一个匹配元素的索引   |
| `FindLastIndex(Predicate<T> match)`               | 返回数组中的最后一个匹配元素的索引 |
| `ForEach(Action<T> action)`                       | 对指定数组的每个元素执行指定操作   |
| `ForEach(Action<int, T> action)`                  | 对指定数组的每个元素执行指定操作   |
