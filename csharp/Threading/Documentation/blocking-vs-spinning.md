# Blocking vs. Spinning

- ***Blocking***
  - Blocked threads do not consume CPU
  - Blocked threads do consume memory
- ***Spinning***
  - Consume CPU for as long as the thread is blocked
  - while(x < limit) // uses CPU as long as the condition is not met