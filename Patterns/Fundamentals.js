let message = "Hello",
    counter = 100;

let message = 'Hello';
message = 100;

//---Undefined vs. undeclared variables ---
    let message;
    console.log(message); // undefined

    console.log(counter); //ReferenceError: counter is not defined


// ---Constants

    const workday = 5;
    workday = 2; //Uncaught TypeError: Assignment to constant variable.

// --- Data types --- 

    null
    undefined
    boolean
    number
    string
    symbol // available from ES2015
    bigint // available from ES2020



    let counter = 120;
    console.log(typeof (counter)); // "number"

    counter = false;
    console.log(typeof (counter)); // "boolean"

    counter = "Hi";
    console.log(typeof (counter)); // "string"


// ---number---

    let num = 0o71; //octal (starts with zero or 0o (es6))
    console.log(num);;

    let num = 0x1a; //  Hexadecimal (0x or 0X)
    console.log(num); // 26

    let tax = 0.08; // float

    let amount = 3.14e7;
    console.log(amount); // 31400000

    let amount = 5e-7;
    console.log(amount); // 0.0000005

    const budget = 1_000_000_000;

    // binary
    let nibbles = 0b1011_0101_0101; // es6 , before parseInt('111',2);

// ---boolean---

    //Data Type	    Values converted to true	Value Converted to false
    //string	    Any non - empty string	    “” (empty string)
    //number	    Any Non - zero number	    0, NaN
    //object	    Any object	                null
    //undefined     (not relevant)	            undefined


//--- NAN

    console.log('a' / 2); // NaN;

    //Any operation with NaN returns NaN.
    //The NaN does not equal any value, including itself.


// ---bigint--- (  > 2^53 – 1)
    let pageView = 9007199254740991n;


// ---Primitive vs. Reference Values---

    /* primitive types + references to objects - to stack , object itself to heap
     string - primitive

    */

// ---Arrays---

    let scores = new Array(9, 10, 8, 7, 6);

    let arrayName = [element1, element2, element3, ...];

    //basic operations
    let seas = ['Black Sea', 'Caribbean Sea', 'North Sea', 'Baltic Sea'];

    seas.push('Red Sea'); // add at the end
    seas.pop(); // remove from the end
    seas.unshift('Red Sea'); // add at the beginning
    seas.shift('Red Sea'); // remove

    console.log(Array.isArray(seas)); // true