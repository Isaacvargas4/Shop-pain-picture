

let theForm = document.getElementById("theForm");
console.log(theForm)
theForm.hidden = true

let button = document.getElementById("buyButton")

button.addEventListener("click", () => theForm.hidden = false)


