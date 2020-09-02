#pragma once
#ifndef __COMPLEX_H__
#define __COMPLEX_H__
#include <iostream>

class Complex
{
public:
	Complex();							  // 默认构造函数
	Complex(double r, double i);		  // 构造函数
	virtual ~Complex();					  // 析构函数
	Complex(const Complex &x);			  // 拷贝构造
	Complex &operator=(const Complex &c); // =号运算符

	double GetReal() const { return _real; }
	void SetReal(double d) { _real = d; }
	double GetImage() const { return _image; }
	void SetImage(double i) { _image = i; }

	// 运算符重载
	Complex operator+(const Complex &c) const;
	Complex &operator+=(const Complex &c);
	Complex operator-(const Complex &c) const;
	Complex &operator-=(const Complex &c);
	Complex operator*(const Complex &c) const;
	Complex &operator*=(const Complex &c);
	Complex operator/(const Complex &c) const;
	Complex &operator/=(const Complex &c);

	bool operator==(const Complex &c) const;
	bool operator!=(const Complex &c) const;
	bool operator>(const Complex &c) const;
	bool operator>=(const Complex &c) const;
	bool operator<(const Complex &c) const;
	bool operator<=(const Complex &c) const;

	// 前置和后置++
	Complex &operator++();	 //前置++
	Complex operator++(int); //后置++
	Complex &operator--();	 //前置--
	Complex operator--(int); //后置--

	//protected:
	friend std::ostream &operator<<(std::ostream &os, const Complex &x);
	friend std::istream &operator>>(std::istream &is, Complex &x);

private:
	double _real;  // 复数的实部
	double _image; // 复数的虚部
};
#endif