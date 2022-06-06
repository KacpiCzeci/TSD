def fifteen_points(text: String, word1: String, word2: String): String = {
  var occ1 = 0;
  var occ2 = 0;
  for(i<-0 to text.length-word1.length){
      if(text.substring(i, i+word1.length).equals(word1)){
        occ1 = occ1 + 1;
      }
  }
  for(i<-0 to text.length-word2.length){
      if(text.substring(i, i+word2.length).equals(word2)){
        occ2 = occ2 +  1;
      }
  }
  return word1 + ": " + occ1 + ", " + word2 + ": " + occ2;
}

println(fiveteen_points("abc cdef dcccd wccddwc abc xd sdc ss xd xd xd", "abc", "xd"));








