export default  function ToggleDarkMode() {
   const element  = document.querySelector("html")
   if(element)
      element.classList.toggle("my-app-dark")
}
