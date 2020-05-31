This table is handy for using `*` and `**` in function _construction_ and function _call_:

                In function construction         In function call
    =======================================================================
              |  def f(*args):                 |  def f(a, b):
    *args     |      for arg in args:          |      return a + b
              |          print(arg)            |  args = (1, 2)
              |  f(1, 2)                       |  f(*args)
    ----------|--------------------------------|---------------------------
              |  def f(a, b):                  |  def f(a, b):
    **kwargs  |      return a + b              |      return a + b
              |  def g(**kwargs):              |  kwargs = dict(a=1, b=2)
              |      return f(**kwargs)        |  f(**kwargs)
              |  g(a=1, b=2)                   |
    -----------------------------------------------------------------------

This really just serves to summarize Lorin Hochstein's [answer](https://stackoverflow.com/a/36926/7954504) but I find it helpful.

Relatedly: uses for the star/splat operators have been [expanded](https://docs.python.org/3/whatsnew/3.5.html#pep-448-additional-unpacking-generalizations) in Python 3