# Thread Pool

- Every thread has overhead in time and memory
- Thread pools reduce the performance penalty by sharing and recycling threads
- Thread pools only create background threads
- Limits the number of the threads that can run simultaneously
- When limit is reached, all jobs form a queue and begin only when another job finishes
- <code>Thread.CurrentThread.IsThreadPoolThread</code> property - determines if execution is happening on a pool thread