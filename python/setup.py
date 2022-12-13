from setuptools import find_packages, setup

setup(
    name='captureclientapi',
    packages=find_packages(include=['captureclientapi']),
    version='0.1.0',
    author_email='ilinked1337@protonmail.com',
    description='Wrapper for the CAPTURE Client API',
    setup_requires=['requests'],
    author='iLinked',
    license='MIT',
)
