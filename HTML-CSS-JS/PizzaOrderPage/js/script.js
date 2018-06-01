/* Include iteration through object values to get next item to work on
if item = array then use getMeat and below else if single value, feed to checked function not made
 Object.keys(obj).forEach(function (key) {
  var value = obj[key];
  // do something with key or value
}); */


//PIZZA ORDER OBJECT LITERAL
var pizzaOrder = {
//Size prices 6, 10, 14, 16  
   sizeValue : "Personal",
/* 
Meat prices $1 for every over 1 
Use array to store the checkboxes on array length?
*/
    meatValue : [],
//$3 for extra cheese, no discount for cheese free
   cheeseValue: "Regular",
//Veggie prices $1 for every over 1
   veggieValue: [],
//$3 for cheese stuffed crust
   crustValue: "Plain",
//Sauce Selection $0
   sauceValue: "Marinara",
//total Cost array
    totalValue: [],
    getValues: function ()
    {
        pizzaOrder.sizeValue = $("input[name='Size']:checked").val();
        pizzaOrder.crustValue = $("input[name='crust']:checked").val();
        pizzaOrder.cheeseValue = $("input[name='cheese']:checked").val();
        pizzaOrder.sauceValue = $("input[name='sauce']:checked").val();
        pizzaOrder.meatValue.length = 0;
        pizzaOrder.veggieValue.length = 0;
        pizzaOrder.totalValue[5] = 0;
        Object.keys(pizzaOrder).forEach(function (key) {
            switch (key){
                case "meatValue":
                    getMeat();
                    //console.log(pizzaOrder.meatValue)
                    break;
                case "veggieValue":
                    getVeggie();
                    //console.log(pizzaOrder.veggieValue)
                    break;        
            }
        });
        function getMeat()     
        {
            var meatValue = [];
            var checkValue = document.getElementsByName('Meat');
            var checkLength = checkValue.length
            for (var i=0; i<checkLength; i++)
            {
                if(checkValue[i].type == 'checkbox' && checkValue[i].checked == true){
                    meatValue.push(checkValue[i].value);
                }
            }
            pizzaOrder.meatValue = meatValue;
    
        }
        function getVeggie()     
        {
            var veggieValue = [];
            var checkValue = document.getElementsByName('veggie');
            var checkLength = checkValue.length
            for (var i=0; i<checkLength; i++)
            {
                if(checkValue[i].type == 'checkbox' && checkValue[i].checked == true){
                    veggieValue.push(checkValue[i].value);
                }
            }
            pizzaOrder.veggieValue = veggieValue;
    
        } 
          
        
    }
};

function completeOrder(frm)
{
    //Set pizzaOrder Values
    pizzaOrder.getValues();
    $("#myTable tr").remove(); 
    calculatePrice();
    displayOrder();  
}

  

//Must call pizzaOrder.getValues() first to populate pizzaOrder
function calculatePrice(){
    //Calculate Crust Component
    switch(pizzaOrder.sizeValue){
        case "Personal":
            pizzaOrder.totalValue[0] = 6;
            break;
        case "Medium":
             pizzaOrder.totalValue[0] = 10;
            break;
        case "Large":
            pizzaOrder.totalValue[0] = 14;
            break;
        case "Extra Large":
            pizzaOrder.totalValue[0] = 16;
            break;
    }
    //Calculate Meat Component
    pizzaOrder.totalValue[1] = (pizzaOrder.meatValue.length > 1) ? pizzaOrder.meatValue.length-1 : 0;
    //Calculate Cheese Component
    pizzaOrder.totalValue[2] = (pizzaOrder.cheeseValue == "Extra Cheese")  ? 3:0;
    //Calculate Crust Component
    pizzaOrder.totalValue[3] = (pizzaOrder.crustValue == "Cheese Stuffed Crust")  ? 3:0;
    //Calculate Veggie Componenet
    pizzaOrder.totalValue[4] = (pizzaOrder.veggieValue.length > 1) ? pizzaOrder.veggieValue.length-1 : 0

    for (i=0; i<5; i++){
        pizzaOrder.totalValue[5] += pizzaOrder.totalValue[i]
    }
    
}

function displayOrder(){
   
    myTable = document.getElementById('myTable');
    
    //Print Total
    var row = myTable.insertRow(0); 
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = "Total:";
    cell2.innerHTML = "$" + pizzaOrder.totalValue[5];
    //Print Sauce
    var row = myTable.insertRow(0); 
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = pizzaOrder.sauceValue;
    cell2.innerHTML = "";
    
    //Print Cheese
    if(pizzaOrder.cheeseValue == "Extra Cheese"){
    var row = myTable.insertRow(0);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = pizzaOrder.cheeseValue;
    cell2.innerHTML = "$"+pizzaOrder.totalValue[2];
    }else if (pizzaOrder.cheeseValue == "No Cheese"){
        var row = myTable.insertRow(0);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        cell1.innerHTML = pizzaOrder.cheeseValue;
        cell2.innerHTML = ""; 
    }
    //Print Veggies
    if(pizzaOrder.veggieValue.length != 0){
        var row = myTable.insertRow(0);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        cell1.innerHTML = pizzaOrder.veggieValue;
        cell2.innerHTML = "$"+pizzaOrder.totalValue[4];
    }else{
        var row = myTable.insertRow(0);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        cell1.innerHTML = "No Vegetables";
        cell2.innerHTML = "$"+0;
    }

        //Print Meat
    if (pizzaOrder.meatValue.length != 0){
        var row = myTable.insertRow(0);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        cell1.innerHTML = pizzaOrder.meatValue;
        cell2.innerHTML = "$"+pizzaOrder.totalValue[1];
    } else{
        var row = myTable.insertRow(0);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        cell1.innerHTML = "No Meat";
        cell2.innerHTML = "$"+0;
    }
        //Print Crust type
    var row = myTable.insertRow(0); 
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = pizzaOrder.crustValue;
    cell2.innerHTML = "$"+pizzaOrder.totalValue[3];
    //Print CrustSize
    var row = myTable.insertRow(0); 
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    cell1.innerHTML = pizzaOrder.sizeValue + " Crust Size";
    cell2.innerHTML = "$"+pizzaOrder.totalValue[0];
    var l = (document.getElementById("myTable").rows.length)-1;
    document.getElementById("myTable").rows[l].className = "table-danger";
    document.getElementById("receipt").style.display = "inherit";

}
function formReset(){
    document.getElementById("form1").reset();
    pizzaOrder.getValues();
    $("#myTable tr").remove();
    //document.getElementById("receipt").className = "invisible";
    document.getElementById("receipt").style.display = "none";
}

