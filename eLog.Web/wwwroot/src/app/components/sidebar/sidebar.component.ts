import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    { path: '/user-profile', title: 'User Profile', icon: 'person', class: '' },
    { path: '/user', title: 'User', icon: 'person', class: '' },
    { path: '/leave', title: 'Leave/TimeOff', icon: 'watchlater', class: '' },
    { path: '/leavesetting', title: 'Leave Setting', icon: 'settings', class: '' },
    { path: '/companylist', title: 'Company', icon: 'person', class: '' },
    { path: '/holiday', title: 'Holiday', icon: 'holiday_village', class: '' },
    { path: '/employee-type', title: 'EmployeeType', icon: 'holiday_village', class: '' },
    { path: '/workingdayslist', title: 'WorkingDays', icon: 'person', class: '' },
    { path: '/department', title: 'Department', icon: 'person', class: '' },
    { path: '/login', title: 'Login', icon: 'login', class: '' },
    { path: '/userlogin', title: 'Userlogin', icon: 'login', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
