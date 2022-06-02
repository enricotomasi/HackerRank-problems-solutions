#!/bin/bash

for x in {1..100}
do

    controllo=$(($x % 2))
    if [ $controllo -ne 0 ];
    then
        echo $x 
    fi

done
