//let variables are blocked-scope
//In JavaScript, blocks are denoted by curly braces {}

let x = 10;
if (x == 10) {
    let x = 20;
    console.log(x); // 20:  reference x inside the block
}
console.log(x); // // 10: reference at the begining of the script

//Because the let keyword declares a block-scoped variable,
//the x variable inside the if block is a new variable and it shadows the x variable declared at the top of the script

for (var i = 0; i < 5; i++) {
    setTimeout(function () {
        console.log(i);
    }, 1000);
}

//5 5 5 5 5

{
    console.log(counter); // Uncaught ReferenceError: Cannot access 'counter' before initialization
    let counter = 10;
}

//JavaScript engine will hoist a variable declared by the let keyword to the top of the block
//However, the JavaScript engine does not initialize the variable.