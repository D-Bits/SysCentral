"""
Run this file to automate self-contained deployments (SCDs).
"""
from subprocess import run


# Define necessary commands
def dotnet_cmds():

    # Restore the project before compiling 
    run(['dotnet', 'restore'])

    # Build for all target operating systems
    run(['dotnet', 'build', '-r', 'win10-x64'], check=True)
    run(['dotnet', 'build', '-r', 'osx.10.14-x64'], check=True)
    run(['dotnet', 'build', '-r', 'ubuntu.18.04-x64'], check=True)

    # Publish all
    run(['dotnet', 'publish', '-c', 'win10-x64'], check=True)
    run(['dotnet', 'publish', '-c', 'osx.10.14-x64'], check=True)
    run(['dotnet', 'publish', '-c', 'ubuntu.18.04-x64'], check=True)


dotnet_cmds()