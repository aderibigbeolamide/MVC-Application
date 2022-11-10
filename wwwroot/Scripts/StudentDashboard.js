let postelect = document.querySelector(".renderElection");



const renderelect = () => {
    // alert('hello');
    var getdata = JSON.parse(window.localStorage.getItem("action"));
    postelect.innerHTML = "";
    getdata.forEach(post => {
        let newPost = ElectionTem
        .replace('{POST-PRESIDENT}', post.electionName)
        .replace('{POST-STARTDATE}', post.startdate)
        .replace('{POST-ENDDATE}', post.enddate)
        .replace('{POST-POSITIONNAME}', post.positionName)
        postelect.innerHTML += newPost;
    });
}
 
renderelect();