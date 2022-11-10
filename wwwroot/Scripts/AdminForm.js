let fullName = document.querySelector('#fullName');
let gender = document.querySelector('.gender');
let dateofbirth = document.querySelector('#dateofbirth');
let email = document.querySelector('#email');
let phoneNumber = document.querySelector('#phoneNumber');
let address = document.querySelector('#address');
let password = document.querySelector('#password');
const log = document.querySelector('.login');

function Signup() {
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
    }
    else {
        document.querySelectorAll("result").innerHTML = "Sorry your browser does not support web Storage."
    }

    form();
}


form.addEventListener('submit', (e) => {
    e.preventDefault();
    if (typeof (fullName.value) === 'number') {
        window.alert('Name is required')
    }
    if (gender.value === '') {
        window.alert('Gender is required')
    }
    // if (email.value === '') {
    //     window.alert('Email is required')
       
    // }
    assign.forEach(objs => {
        if (objs.email == email.value) {
            flag = false;
            span = document.createElement("span");
            span.textContent = "This email belongs to another Admin, enter another email";
            span.style.color = "red";
            email.after(span);
        }
    });
    if (password.value === '') {
        window.alert('Password is required and Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters ')
    }
    if (dateofbirth.value === '') {
        window.alert('level is requreid ')
    }
    if (isNaN(phoneNumber.value) === '') {
        window.alert('PhoneNumber  is  required ')
    }
    if (phoneNumber.value.length < 11) {
        window.alert('PhoneNumber  must  be 11 digit ')
    }
    if (typeof (address.value) === 'number') {
        window.alert('address is requreid ')
    }
    // if (window.alert().length > 0) {
    //    e.preventDefault()
    //    errorElement.innerText = alert.join(',')
    // }
    alert("Signup Successful");
    location.href = "Admindashboard.html"

})


//Login Validation

let attempt = 3;

const login = () => {
    log.addEventListener('submit', (e) => {
        e.preventDefault();
        var assign = JSON.parse(localStorage.getItem('result'));
        let emaill = document.querySelector('#emaill');
        let passwordl = document.querySelector('#passwordl');
        for (let index = 0; index < assign.length; index++) {
            if (emaill.value == assign[index].email && passwordl.value == assign[index].password) {
                alert("Login successfull");
                window.location.href = "Admindashboard.html" // Redirect to dashboard
            }
            else {
                attempt--;
                alert("You have" + attempt + " attempt left; ");
                alert("Please check your matricNo or Password");
                if (attempt == 0) {
                    document.querySelector('#matricNo').disabled = true;
                    document.querySelector('#password').disabled = true;
                    document.querySelector('#login').disabled = true;
                    return false;
                }
            }
            
        }
    })
}


