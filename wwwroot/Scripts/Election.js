let electionName = document.querySelector('#electionName');
let startdate = document.querySelector('#startdate');
let enddate = document.querySelector('#enddate');
let positionName = document.querySelector('#positionName');
const form = document.getElementById('form');



function election() {
    alert("hello");
    const elect = (() => {
        const use = localStorage.getItem("action");
        return use === null ? [] : JSON.parse(use);
    })();
    elect.push({
        electionName: `${electionName.value}`,
        startdate: `${startdate.value}`,
        enddate: `${enddate.value}`,
        positionName: `${positionName.value}`
    });
    console.log(elect);
    if (typeof (Storage) !== "undefined") {
        localStorage.setItem("action", JSON.stringify(elect));
        localStorage.getItem("action");
    }
    else {
        document.querySelectorAll("action").innerHTML = "Sorry your browser does not support web Storage."
    }
    form();
}

function validate() {
    e.preventDefault();
    if (electionName.value === '') {
        window.alert('electionName is required')
    }
    if (startdate.value === '') {
        window.alert('startdate is required ')
    }
    if (enddate.value === '') {
        window.alert('enddate is requreid ')
    }
    alert("Election Created Successful");
    location.href = "Election.html"
};

form.addEventListener('submit', validate, (e) => {
    if (window.alert().length > 0) {
        e.preventDefault()
        errorElement.innerText = alert.join(',')
    }
    alert("Election Created Successful");
    location.href = "Election.html"

})






