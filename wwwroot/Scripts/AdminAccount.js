let fullName = document.querySelector('#fullName');
let gender = document.querySelector('.gender');
let dateofbirth = document.querySelector('#dateofbirth');
let email = document.querySelector('#email');
let phoneNumber = document.querySelector('#phoneNumber');
let address = document.querySelector('#address');
let password = document.querySelector('#password');
const form = document.querySelector('.form');

function Update() {
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        const sub = (() => {
            const assign = localStorage.getItem("data");
            return assign === null ? [] : JSON.parse(assign);
        })();
        sub.push({
            fullName: `${fullName.value}`,
            gender: `${gender.value}`,
            dateofbirth: `${dateofbirth.value}`,
            email: `${email.value}`,
            phoneNumber: `${phoneNumber.value}`,
            address: `${address.value}`,
            password: `${password.value}`
        });
        console.log(sub);
        if (typeof (Storage) !== "undefined") {
            localStorage.setItem("result", JSON.stringify(sub));
            localStorage.getItem("result");
            alert("Update successfull");
        }
        else {
            document.querySelectorAll("result").innerHTML = "Sorry your browser does not support web Storage."
        }
            
    })
}