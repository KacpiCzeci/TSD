def ten_points(lst: Array[Int], n: Int): Array[Int] = {
  if(n >= lst.length){
    lst;
  }
  else {
    var minimum = Integer.MAX_VALUE;
    var sum = 0;
    var min_list = new Array[Int](3);
    for(i<-0 to lst.length-3){
      if(lst.slice(i, i+3).sum < minimum){
        minimum = lst.slice(i, i+3).sum;
        min_list = lst.slice(i, i+3);
      }
    }
    min_list;
  }
}

println(ten_points(Array(23, 4, 6, 70, 1, 3, 6, 0, 9, 1, 60, 13), 3).mkString(","));








