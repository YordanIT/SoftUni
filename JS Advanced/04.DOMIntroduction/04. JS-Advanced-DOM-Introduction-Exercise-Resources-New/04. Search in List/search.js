function search() {
   let searchText = document.getElementById('searchText').value;
   let allLiElements = Array.from(document.querySelectorAll('#towns li'));
   
   allLiElements.forEach(el => {
      el.style.fontWeight = 'normal';
      el.style.textDecoration = 'none';
   });

   let matchedLis = allLiElements
   .filter(x => x.textContent.toLowerCase().includes(searchText))
   .map(x => {
      x.style.fontWeight = 'bold';
      x.style.textDecoration = 'underline';
   });

   let result = `${matchedLis.length} matches found`
   let resultDiv = document.getElementById('result');
   resultDiv.textContent = result;
}
