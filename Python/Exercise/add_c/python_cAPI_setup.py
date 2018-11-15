#build the python_cAPI_adder.c modules
from distutils.core import setup,Extension
setup(name='addList', version='1.0', \
ext_modules=[Extension('addList', ['python_cAPI_adder.c'])])

# python python_cAPI_setup.py install