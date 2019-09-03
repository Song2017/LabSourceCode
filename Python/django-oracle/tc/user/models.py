from django.db import models

# Create your models here.


class UserTest(models.Model):
    class Meta:
        verbose_name = 'UserTest'
    name = models.CharField(default="", max_length=100)
    passwd = models.CharField(default="", max_length=100)
