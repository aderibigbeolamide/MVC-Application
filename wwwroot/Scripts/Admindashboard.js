const li_item = document.querySelectorAll(".sidebarbrand ul li");
const sidebar = document.querySelector(".sidebar");

li_item.forEach((li_item) => {
    li_item.addEventListener("mouseenter", ()=>{
        if (sidebar.classList.contains("click-collapes")) {
            return;
        }
        else{
            li_item.closest(".sidebar").classList.remove("hover-collapes");
        }
    })
})

li_item.forEach((li_item) => {
    li_item.addEventListener("mouseleave", () => {
        if (sidebar.classList.contains("click.collapes")) {
            return;
        } else {
            li_item.closest(".sidebar").classList.add("hover.collapes");
        }
    })
})

