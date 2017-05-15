# HuffmanCodeTest
A very simple program to calculate (extended) Huffman code of given alphabet. The efficiency becomes tolerable after the first update (by changing sorting to inserting).

## Example:

```
Input the symbol and its probability (e.g. A 0.5), use "." to stop:
> A 0.5
> B 0.3
> C 0.2
> .
Extend time
> 1
Time lapsed for 0.0020172 second(s)

Results:
===========================================
  AA, p=0.25000, Code=01
  AB, p=0.15000, Code=001
  AC, p=0.10000, Code=111
  BA, p=0.15000, Code=000
  BB, p=0.09000, Code=1000
  BC, p=0.06000, Code=1010
  CA, p=0.10000, Code=110
  CB, p=0.06000, Code=1001
  CC, p=0.04000, Code=1011
--------------------------------------
Average Codeword Length = 3
Entropy = 2.970951
Efficiency = 0.9903169
Press any key to continue.
```
