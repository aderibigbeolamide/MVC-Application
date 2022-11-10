const renderview = document.querySelector('.renderview');
let newpostelect = document.querySelector(".renderElection");

const Viewrender = () => {
    var newdate = JSON.parse(window.localStorage.getItem("contest"));
    renderview.innerHTML = "";
    newdate.forEach(element => {
        let newelement = ContestTem
        .replace('{POST-FULLNAME}', element.fullNamen)
        .replace('{POST-GRADE}', element.GPn)
        .replace('{POST-DEPARTMENT}', element.departmentn)
        .replace('{POST-LEVEL}', element.leveln)
        .replace('{POST-MESSAGE}', element.message)
        renderview.innerHTML += newelement;
    });
}

const renderelect = () => {
    // alert('hello');
    var getdata = JSON.parse(window.localStorage.getItem("action"));
    newpostelect.innerHTML = "";
    getdata.forEach(post => {
        let newPost = ElectionTem
        .replace('{POST-PRESIDENT}', post.electionName)
        .replace('{POST-STARTDATE}', post.startdate)
        .replace('{POST-ENDDATE}', post.enddate)
        .replace('{POST-POSITIONNAME}', post.positionName)
        newpostelect.innerHTML += newPost;
    });
}
 
renderelect();

Viewrender();