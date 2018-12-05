#!/bin/sh

projectDir=$(dirname "$0")
destFile="$projectDir/litter-box.unitypackage"
echo "Project Dir: ${projectDir}"
echo "Detination File: ${destFile}"

if hash Unity 2>/dev/null; then
  Unity \
    -batchmode \
    -nographics \
    -quit \
    -projectPath "$projectDir" \
    -exportPackage Assets/Scripts/LitterBox "$destFile"
else
  echo "No Command 'Unity' found on path. Make sure you have added Unity command line tools to your path"       	
fi
