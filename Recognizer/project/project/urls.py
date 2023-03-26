from django.contrib import admin
from django.urls import path, include
from django.conf import settings
from django.conf.urls.static import static
from project import views as vw

urlpatterns = [
    path('test', vw.test , name='test'),
    path('result', vw.result, name='result'),
]