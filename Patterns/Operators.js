// --- Strict equal (===) and not strict equal (!==)
    console.log("10" == 10); // true 
    console.log("10" === 10); // false  If the operands are of different types, return false.


// --- Logical Assignment Operators (ES 2021)

    let title;
    title ||= 'untitled';

    console.log(title); // untitled

    let person = {
        firstName: 'Jane',
        lastName: 'Doe',
    };

    person.lastName &&= 'Smith';

    console.log(person); //{firstName: 'Jane', lastName: 'Smith'}

    //The nullish coalescing assignment operator only assigns y to x if x is null or undefined:
    let user = {
        username: 'Satoshi'
    };
    user.nickname ??= 'anonymous';

    console.log(user); { username: 'Satoshi', nickname: 'anonymous' }