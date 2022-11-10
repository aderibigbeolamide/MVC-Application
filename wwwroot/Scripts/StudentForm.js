let fullName = document.querySelector('#fullName');
let gender = document.querySelector('.gender');
let level = document.querySelector('#level');
let GP = document.querySelector('#GP');
let department = document.querySelector('#department');
let email = document.querySelector('#email');
let phoneNumber = document.querySelector('#phoneNumber');
let address = document.querySelector('#address');
let matricNo = document.querySelector('#matricNo');
let password = document.querySelector('#password');
const form = document.getElementById('form');
const log = document.querySelector('.login');
// const objs = [];
function Signup() {
   const obj = (() => {
      const item = localStorage.getItem("data");
      return item === null ? [] : JSON.parse(item);
   })();
    obj.push({
      fullName: `${fullName.value}`,
      gender: `${gender.value}`,
      level: `${level.value}`,
      GP: `${GP.value}`,
      department: `${department.value}`,
      email: `${email.value}`,
      phoneNumber: `${phoneNumber.value}`,
      address: `${address.value}`,
      matricNo: `${matricNo.value}`,
      password: `${password.value}`
    })
   console.log(obj);
   if (typeof (Storage) !== "undefined") {
      localStorage.setItem("data", JSON.stringify(obj));
   }
   else {
      document.querySelectorAll("data").innerHTML = "Sorry your browser does not support web Storage."
   }

form();
}

function checkForm(){
   e.preventDefault();
   if (typeof(fullName.value) === 'number') {
      window.alert('Name is required')
   }
   if (gender.value === '') {
      window.alert('Gender is required')
   }
   if (email.value === '' ) {
      window.alert('Email is required')
   }
   if (password.value === '') {
      window.alert('Password is required and Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters ')
   }
   if (matricNo.value === '' ) {
      window.alert('matricNo is requreid ')
   }
   if (isNaN(level.value) === '' ) {
      window.alert('level is requreid ')
   }
   if (isNaN(GP.value) === '' ) {
      window.alert('GP is requreid ')
   }
   if (typeof(department.value) === 'number') {
      window.alert('department is requreid ')
   }
   if (isNaN(phoneNumber.value) === '') {
      window.alert('PhoneNumber  is  required ')
   }
   if (phoneNumber.value.length < 11) {
      window.alert('PhoneNumber  must  be 11 digit ')
   }
   if (typeof(address.value) === 'number' ) {
      window.alert('address is requreid ')
   }
   // if (window.alert().length > 0) {
   //    // e.preventDefault()
   //    errorElement.innerText = alert.join(',')
   // }
   alert("Signup Successful");
   location.href = 'Studentdashboard.html'
  
};

form.addEventListener('submit', checkForm, (e) => {
    if (window.alert().length > 0) {
      e.preventDefault()
      errorElement.innerText = alert.join(',')
   }
   alert("Signup Successful");
   location.href = 'Studentdashboard.html'

})


//Login Validation

let attempt = 3;

const login = () => {
   log.addEventListener('submit', (e) =>{
      e.preventDefault();
      var item = JSON.parse(localStorage.getItem('data'));
      const matricNol = document.querySelector('#matricNol');
      const passwordl = document.querySelector('#passwordl');
      for (let index = 0; index < item.length; index++) {
         if (matricNol.value == item[index].matricNo && passwordl.value == item[index].password) {
            console.log(item);
            alert("Login successfull");
            window.location.href = "Studentdashboard.html" // Redirect to dashboard
         }
         else {
            console.log(password.value);
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
