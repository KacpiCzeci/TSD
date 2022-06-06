def five_points(str: String): String = {
  str.dropRight(4) + str.takeRight(4).toUpperCase();
} 

println(five_points("A wiec wojna. Z dniem dzisiejszym wszelkie sprawy i zagadnienia schodza na plan dalszy."))
println(five_points("abc"))








