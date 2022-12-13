from setuptools import find_packages, setup

setup(
    name='captureclientapi',
    packages=find_packages(include=['captureclientapi']),
    version='0.0.1',
    description='Wrapper for the CAPTURE Client API',
    setup_requires=['requests'],
    author='iLinked',
    license='MIT',
)