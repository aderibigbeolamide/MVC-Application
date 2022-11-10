let fullNamens = document.querySelector('#fullNamens');
let leveln = document.querySelector('#leveln');
let GPn = document.querySelector('#GPn');
let departmentn = document.querySelector('#departmentn');
let message = document.querySelector('#message');
let apply = document.querySelector('.apply');
const newform = document.getElementById('form');


function Apply() {
    apply.addEventListener('click', (e) => {
        e.preventDefault();
        location.href = '/ContestForm.html';
    })
}

function Studentcontest() {
   const rerend = (() => {
      const contestItems = localStorage.getItem("studentcontest");
      return contestItems === null ? [] : JSON.parse(contestItems);
   })();
   rerend.push({
      fullNamens: `${fullNamens.value}`,
      leveln: `${leveln.value}`,
      GPn: `${GPn.value}`,
      departmentn: `${departmentn.value}`,
      message: `${message.value}`,
   })
   alert("Hello");
    console.log(rerend);
    if (typeof (Storage) !== "undefined") {
       localStorage.setItem("studentcontest", JSON.stringify(rerend));
    }
    else {
       document.querySelectorAll("studentcontest").innerHTML = "Sorry your browser does not support web Storage."
    }
newform();
 }

 function check() {
   e.preventDefault();
   if (fullNamens.value === '') {
       window.alert('FullName is required')
   }
   if (leveln.value === '') {
       window.alert('Level is required ')
   }
   if (GPn.value === '' & GPn.value < 4.5) {
       window.alert('Your not elegible ')
   }
   alert("Election Created Successful");
   location.href = "Studentdashboard.html"
};

newform.addEventListener('submit', validate, (e) => {
   if (window.alert().length > 0) {
       e.preventDefault()
       errorElement.innerText = alert.join(',')
   }
   alert("Election Created Successful");
   location.href = "Studentdashboard.html"

})

