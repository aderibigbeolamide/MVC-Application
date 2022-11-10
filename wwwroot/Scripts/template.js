const ElectionTem = `
<h2>{POST-PRESIDENT}</h2>
            <h3>{POST-STARTDATE}</h3>
            <h3>{POST-ENDDATE}</h3>
            <h3>{POST-POSITIONNAME}</h3>
            <button onclick="Apply()" class="apply">Apply</button>`;


const ContestTem = `
<div class="view-main-block">
<div class="one">
    <h3>{POST-FULLNAME}</h3>
<h3>{POST-GRADE}</h3>
</div>
<div class="one">
    <h3>{POST-DEPARTMENT}</h3>
    <h3>{POST-LEVEL}</h3>
</div>
<div class="one">
    <h3>{POST-PRESIDENT}</h3>
    <h3>{POST-STARTDATE}</h3>
</div>
<div class="one">
    <h3>{POST-ENDDATE}</h3>
    <h3>{POST-POSITIONNAME}</h2>
</div>
<p>{POST-MESSAGE}</p>
<button onclick="vote()" class="vote">vote</button>
</div>`;