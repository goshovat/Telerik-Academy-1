

/*
    Strings are sequences of characters. Each character is a Unicode symbol to support multiple languages and alphabets.
    They are immutable(read-only). In C# System.String is a reference type. It has a fixed length and its elements can be
    accessed directly by index. The index is in the range [0,...Length - 1].
    Strings can be initialized by:
        - Assigning a string literal to the string variable
        - Assigning the value of another string variable
        - Assigning the result of operation of type string
    Before initializing a string variable has null value.

    Most important string processing members are:
        - Length 
        - this[]
        - Compare(str1, str2) 
        - IndexOf(str)
        - LastIndexOf(str)
        - Substring(startIndex, length)
        - Replace(oldStr, newStr)
        - Remove(startIndex, length)
        - ToLower()
        - ToUpper()
        - Trim()
*/