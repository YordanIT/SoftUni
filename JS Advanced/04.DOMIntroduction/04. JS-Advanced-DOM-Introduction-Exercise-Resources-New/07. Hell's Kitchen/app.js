function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let inputText = JSON.parse(document.querySelector('textarea').value);
      let bestRestaurantOutput = document.querySelector('#bestRestaurant p');
      let bestWorkersOutput = document.querySelector('#workers p');

      let restaurant = [0, 0, 0, 0];

      inputText.forEach(x => {
         x = x.match(/[^-,\s]+/g);
         let restaurantName = x.shift();
         let workers = x.filter(e => isNaN(e));
         let salaries = x.filter(e => !isNaN(e));

         if (restaurant[0] === restaurantName) {
            restaurant[2].push(...workers);
            restaurant[3].push(...salaries);
            restaurant[1] = calcAverageSalary(restaurant[3]);
         } else {
            let averageSalary = calcAverageSalary(salaries);
            if (averageSalary > restaurant[1]) {
               restaurant[0] = restaurantName;
               restaurant[1] = averageSalary;
               restaurant[2] = workers;
               restaurant[3] = salaries;
            }
         }
      });

      function calcAverageSalary(salaries) {
         return salaries.reduce((a, b) => Number(a) + Number(b)) / salaries.length;
      }
      function calcHighestSalary() {
         return Math.max.apply(null, restaurant[3]);
      }
      function sortSalaries() {
         let workersWithSalaries = {};
         restaurant[2].forEach((e, i) => {
            workersWithSalaries[e] = restaurant[3][i];
         });
         let sortedWorkers = Object.entries(workersWithSalaries).sort((a, b) => b[1] - a[1]);
         print(sortedWorkers);
      }
      sortSalaries();

      function print(sortedWorkers) {
         bestRestaurantOutput.textContent =
            `Name: ${restaurant[0]} Average Salary: ${(restaurant[1]).toFixed(2)} Best Salary: ${(calcHighestSalary()).toFixed(2)}`
         sortedWorkers.forEach(([name, salary]) => bestWorkersOutput.textContent += `Name: ${name} With Salary: ${salary} `);
      }
   }
}
