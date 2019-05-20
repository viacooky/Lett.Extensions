# System.DateTime

## System.DateTime

### Methods

| Method                                                           | Description                                           |
| ---------------------------------------------------------------- | ----------------------------------------------------- |
| `ToString_Year()`                                                | 格式化为 yyyy                                         |
| `ToString_ShortYear()`                                           | 格式化为 yy                                           |
| `ToString_Month()`                                               | 格式化为 yyyy-MM                                      |
| `ToString_ShortMonth()`                                          | 格式化为 yy-M                                         |
| `ToString_Day()`                                                 | 格式化为 yyyy-MM-dd                                   |
| `ToString_ShortDay()`                                            | 格式化为 yy-M-d                                       |
| `ToString_ShortTime()`                                           | 格式化为 hh:mm:ss tt eg. 11:23:02 PM                  |
| `ToString_Base()`                                                | 格式化为 yyyy-MM-dd HH:mm:ss                          |
| `ToString_Full()`                                                | 格式化为 yyyy-MM-dd HH:mm:ss.fffffff                  |
| `GetTotalDays()`                                                 | 获取时间戳的日表示                                    |
| `GetTotalHours()`                                                | 获取时间戳的小时表示                                  |
| `GetTotalMinutes()`                                              | 获取时间戳的分钟表示                                  |
| `GetTotalSeconds()`                                              | 获取时间戳的秒表示                                    |
| `GetTotalMilliseconds()`                                         | 获取时间戳的毫秒表示                                  |
| `GetTotalMilliseconds()`                                         | 获取时间戳的毫秒表示                                  |
| `SetTime(int hour, int minute, int second, int millisecond = 0)` | 设置 DateTime 的 time 部分                            |
| `StartOfDay()`                                                   | 获取 DateTime 的开始 (year-month-day 00:00:00.000)    |
| `EndOfDay()`                                                     | 获取 DateTime 的结束 (year-month-day 23:59:59.999)    |
| `StartOfWeek()`                                                  | 获取本周开始的 DateTime (year-month-day 00:00:00.000) |
| `EndOfWeek()`                                                    | 获取本周结束的 DateTime (year-month-day 23:59:59.999) |
