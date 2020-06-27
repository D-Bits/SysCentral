"""
Run this file to automate self-contained deployments (SCDs).
"""
from subprocess import run


# Define necessary commands
def dotnet_cmds():

    # Restore the project before compiling 
    restore = run(['dotnet', 'restore'])

    # Build for all target operating systems
    build_win64 = run(['dotnet', 'build', '-r', 'win10-x64'], check=True)
    build_mac64 = run(['dotnet', 'build', '-r', 'osx-x64'], check=True)
    build_linux64 = run(['dotnet', 'build', '-r', 'linux-x64'], check=True)

    # Publish all
    pub_win64 = run(['dotnet', 'publish', '-c', 'win10-x64', '-o', 'executables/win64'], check=True)
    pub_mac64 = run(['dotnet', 'publish', '-c', 'osx-x64', '-o', 'executables/mac64'], check=True)
    pub_linux64 = run(['dotnet', 'publish', '-c', 'linux-x64', '-o', 'executables/linux64'], check=True)

    # Error outputs
    if restore.returncode != 0:
        print(restore.stderr)
    elif build_win64.returncode != 0:
        print(build_win64.stderr)
    elif build_mac64.returncode != 0:
        print(build_mac64.stderr)
    elif build_linux64.returncode != 0:
        print(build_linux64.stderr)
    elif pub_win64.returncode != 0:
        print(pub_win64.stderr)
    elif pub_mac64.returncode != 0:
        print(pub_mac64.stderr)
    elif pub_linux64.returncode != 0:
        print(pub_linux64.stderr)
    else:
        print()
        print("All binaries compiled successfully.")
        print()

dotnet_cmds()