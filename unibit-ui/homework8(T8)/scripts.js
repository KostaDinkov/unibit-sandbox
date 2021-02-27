const userForm = document.getElementById('userForm');

const inputs = document.querySelectorAll('input');
inputs.forEach(i => i.addEventListener('keyup', (e) => {
  if(e.key ==="Enter"){
    userForm.reportValidity()
  }
  
}));

document.getElementById('submitBtn').addEventListener('click',(evt)=>{
  evt.preventDefault();
  let isValid = userForm.checkValidity();
  userForm.reportValidity();

  if(isValid){
    
  }

})