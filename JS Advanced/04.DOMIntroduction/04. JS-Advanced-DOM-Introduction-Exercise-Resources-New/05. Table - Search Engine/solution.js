function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchText = document.getElementById('searchField').value;
      let elements = Array.from(document.querySelectorAll('tbody tr'));

      elements.forEach(el => {
         el.className = ''
      });

      let matchRows = elements.filter(row => {
         let values = Array.from(row.children);
         if (values.some(x => x.textContent.includes(searchText))) {
            row.className = 'select'
         }
      })

      searchText = '';
   }
}