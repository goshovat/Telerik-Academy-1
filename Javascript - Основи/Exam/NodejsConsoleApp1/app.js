function(k){
m=k[0]*k[1];
return k[0]>0?m>0?1:3:m<0?0:2
}

console.log(b([-2, 3]));