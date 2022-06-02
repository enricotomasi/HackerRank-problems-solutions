#!/bin/bash

read carattere

if [ $carattere = "Y" ] || [ $carattere = "y" ];
then
    echo "YES"
else
    echo "NO"
fi
