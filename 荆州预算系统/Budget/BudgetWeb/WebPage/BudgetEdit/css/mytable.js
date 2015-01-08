
window.onload=function showtable(){

   var my_tables=document.getElementsByTagName("table");
   for(var x=0;x<my_tables.length;x++){
	   var table_x= my_tables[x];
	   var li=table_x.getElementsByTagName("tr");
	
	   for (var i=0;i<li.length;i++){
	
		if(i%2==0){
	
		 li[i].style.backgroundColor="#fff";
	
		 li[i].onmouseout=function(){
	
			 this.style.backgroundColor="#fff"
	
		  }
	
		}else{
	
		 li[i].style.backgroundColor="#fff";
	
		 li[i].onmouseout=function(){
	
			 this.style.backgroundColor="#fff"
	
		  }
	
		}
		  li[i].onmouseover=function(){
	
		  this.style.backgroundColor="#D5F4FE";
	
		  }
	   }
   }
}