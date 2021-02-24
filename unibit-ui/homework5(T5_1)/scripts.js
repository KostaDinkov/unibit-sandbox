// string split

const strSplitInput = document.getElementById("strSplitInput");
const strSplitResult = document.getElementById('strSplitResult');

strSplitResult.textContent = `[${strSplitInput.value.split(",").map(x => "'" + x + "'").join(", ")}]`;
strSplitInput.onkeyup = (e) => {
  strSplitResult.textContent = `[${e.target.value.split(",").map(x => "'" + x + "'").join(", ")}]`;
}

// string replace all

const strReplaceAllInput1 = document.getElementById('strReplaceAllInput1');
const strReplaceAllInput2 = document.getElementById('strReplaceAllInput2');
const strReplaceAllInput3 = document.getElementById('strReplaceAllInput3');
const strReplaceAllResult = document.getElementById('strReplaceAllResult');
const strReplaceAllBtn = document.getElementById('strReplaceAllBtn');

strReplaceAllBtn.onclick = (e)=>{
  let oldValue = strReplaceAllInput2.value;
  let newValue = strReplaceAllInput3.value;
  let result = strReplaceAllInput1.value.replaceAll(oldValue,newValue);
  strReplaceAllResult.textContent = result;
}


