// function expression vs function declaration

//Function expressions in JavaScript are not hoisted, unlike function declarations.
//You can't use function expressions before you create them:

console.log(notHoisted) // undefined
//  even though the variable name is hoisted, the definition isn't. so it's undefined.
notHoisted(); // TypeError: notHoisted is not a function

var notHoisted = function () {
    console.log('bar');
};
