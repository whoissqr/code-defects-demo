#!/bin/bash

function getWAR(){
	command='find . -name *.war'
        eval $command
}

function scan(){
	eval appcheck scan $1 |grep 'Appcheck analysis results' -A 2|grep 'SHA1'|sed -e "s/^\s*SHA1:\s*//"
}

function print_license_lib_vuln(){
	eval appcheck result --json $1|jq '.results.components[]|if .["vuln-count"].exact >0 then {num_of_vulns: .["vuln-count"].exact, lib: .lib, license: .license.type} else empty end'
}

warfile=$(getWAR)
sha1=$(scan $warfile)
print_license_lib_vuln $sha1
