var closeBtn = document.getElementById("closeBtn");
console.log(closeBtn);
var apearMsg = document.getElementById("msgAppear");
console.log(apearMsg);
closeBtn.addEventListener("click", () => {
    apearMsg.style.display = "none";
})