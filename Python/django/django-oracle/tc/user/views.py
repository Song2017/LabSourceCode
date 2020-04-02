from django.views.generic.base import View
from django.shortcuts import render
from django.core import serializers
from django.http import JsonResponse

from .models import UserTest

# Create your views here.


class UserListView(View):

    def get(self, req):
        users = UserTest.objects.all()
        json_data = serializers.serialize("json", users)
        return JsonResponse(json_data, safe=False)
