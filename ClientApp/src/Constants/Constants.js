﻿import React from 'react';
import HomeWorkOutlinedIcon from '@material-ui/icons/HomeWorkOutlined';

//настройки стилей панелей
export const HeadBlockHeight = '3em' //высота верхней заголовочной панели
export const MainPanelMargin = 10 //отступ панели MainPanel от окна брауз.
export const NavPanel_StartW = 250 //стартовая ширина NavPanel
export const SepPanel_W = 10 //ширина SepPanel
export const SourcePanel_MinW = 250 //минимальная ширина SourcePanel
export const NavPanel_MinW = 150 //минимальная ширина NavPanel
export const Window_minW = 400 //минимальная ширина окна браузера
//настройки стилей таблицы
export const MinTableCellWidth = 80 //минимальная ширина столбца
export const StartTableWidth = 100//стартовая ширина столбцов по умолчанию
export const TableStartWidths = new Map([//стартовые ширины столбцов таблицы
    ['prop0', 80],
    ['prop1', 150],
    ['prop2', 200],
    ['prop3', 300]
])
export const SelectColor1 = 'hsl(0, 25%, 65%)'//удаление в табл.

//цвет темы и производные цвета
export const ThemeColor1 = 'hsl(120, 25%, 65%)'
const arr = ThemeColor1.split(/\(|\,|%/)
let theme_h = +arr[1].trim()
let theme_l = +arr[2].trim()
let theme_s = +arr[4].trim()
export const ThemeColor2 =
    'hsl(' + theme_h + ',' + Math.round(theme_l * 0.8) +
    '%,' + Math.round(theme_s * 1.08) + '%)'
export const ThemeColor3 =
    'hsl(' + theme_h + ',' + Math.round(theme_l * 0.63) +
    '%,' + Math.round(theme_s * 1.15) + '%)'
export const scrollbarCollor1 =
    'hsl(' + theme_h + ',' + theme_l +
    '%,' + Math.round(theme_s * 0.92) + '%)'
export const scrollbarCollor2 = ThemeColor2

//цвета линий
export const SimpleLineColor = 'rgba(109, 109, 109, 0.8)'
export const SimpleLineStyle = '1px solid ' + SimpleLineColor
export const BoldLineColor = 'rgb(40, 40, 40)'
export const BoldLineStyle = '1px solid ' + BoldLineColor

//цвета выделений
export const SelectColor2 = 'rgba(109, 109, 150, 0.2)'//обычное

//svg иконка 'Фокус' (над деревом)
export const Focus_Icon = () => {
    return (<svg viewBox="0 0 512 512" xmlns="http://www.w3.org/2000/svg"><path d="m276 199.320312v-43.183593h-40v43.183593c-17.085938 6.058594-30.628906 19.648438-36.628906 36.757813h-43.3125v40h43.449218c6.070313 16.925781 19.542969 30.347656 36.492188 36.359375v43.585938h40v-43.585938c16.953125-6.011719 30.421875-19.433594 36.492188-36.359375h43.449218v-40h-43.3125c-6-17.109375-19.542968-30.699219-36.628906-36.757813zm-20 76.558594c-11.027344 0-20-8.972656-20-20s8.972656-20 20-20 20 8.972656 20 20-8.972656 20-20 20zm-196-275.878906h81v40h-81c-11.027344 0-20 8.972656-20 20v80h-40v-80c0-33.085938 26.914062-60 60-60zm452 60v80h-40v-80c0-11.027344-8.972656-20-20-20h-81v-40h81c33.085938 0 60 26.914062 60 60zm-452 412h81v40h-81c-33.085938 0-60-26.914062-60-60v-80h40v80c0 11.027344 8.972656 20 20 20zm412-100h40v80c0 33.085938-26.914062 60-60 60h-81v-40h81c11.027344 0 20-8.972656 20-20zm0 0" /></svg>)
}
//svg иконки для дерева
const Stage_Icon = () => (
    <svg className='stage' version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
        viewBox="0 0 512 512" style={{ enableBackground: 'new 0 0 512 512' }}>
        <g>
            <g>
                <g>
                    <path d="M128,64V0H64C28.654,0,0,28.654,0,64v384c0,35.346,28.654,64,64,64h448V64H128z M32,64c0-17.673,14.327-32,32-32h32v352
				                                     H64c-11.239-0.017-22.281,2.947-32,8.592V64z M480,480H64c-17.673,0-32-14.327-32-32c0-17.673,14.327-32,32-32h64V96h352V480z"/>
                    <polygon points="192,176 224,176 224,144 160,144 160,208 192,208 			" />
                    <polygon points="416,208 448,208 448,144 384,144 384,176 416,176 			" />
                    <rect x="256" y="144" width="32" height="32" />
                    <rect x="320" y="144" width="32" height="32" />
                    <polygon points="224,400 192,400 192,368 160,368 160,432 224,432 			" />
                    <polygon points="448,368 416,368 416,400 384,400 384,432 448,432 			" />
                    <rect x="256" y="400" width="32" height="32" />
                    <rect x="320" y="400" width="32" height="32" />
                    <rect x="160" y="304" width="32" height="32" />
                    <rect x="160" y="240" width="32" height="32" />
                    <rect x="416" y="304" width="32" height="32" />
                    <rect x="416" y="240" width="32" height="32" />
                </g>
            </g>
        </g>
    </svg>
)
const Templates_Icon = () => (
    <svg className="templates" viewBox="0 0 512 512" xmlns="http://www.w3.org/2000/svg"><path d="m492 0h-472c-11.046875 0-20 8.953125-20 20v472c0 11.046875 8.953125 20 20 20h472c11.046875 0 20-8.953125 20-20v-472c0-11.046875-8.953125-20-20-20zm-20 472h-432v-432h432zm-390.140625-334.8125c-7.8125-7.808594-7.8125-20.472656 0-28.285156 7.808594-7.808594 20.472656-7.808594 28.28125 0l12.949219 12.949218 42.769531-42.765624c7.808594-7.8125 20.472656-7.8125 28.28125 0 7.8125 7.8125 7.8125 20.472656 0 28.285156l-56.90625 56.90625c-7.8125 7.8125-20.476563 7.808594-28.285156 0zm154.140625-15.503906c0-11.046875 8.953125-20 20-20h160c11.046875 0 20 8.953125 20 20 0 11.042968-8.953125 20-20 20h-160c-11.046875 0-20-8.957032-20-20zm-154.140625 284.140625c-7.8125-7.8125-7.8125-20.476563 0-28.285157 7.808594-7.808593 20.472656-7.8125 28.28125 0l12.949219 12.949219 42.769531-42.765625c7.808594-7.8125 20.472656-7.8125 28.28125 0 7.8125 7.808594 7.8125 20.472656 0 28.285156l-56.90625 56.90625c-7.8125 7.8125-20.476563 7.808594-28.285156 0zm154.140625-15.507813c0-11.042968 8.953125-20 20-20h160c11.046875 0 20 8.957032 20 20 0 11.046875-8.953125 20-20 20h-160c-11.046875 0-20-8.953125-20-20zm-154.140625-118.808594c-7.8125-7.8125-7.8125-20.476562 0-28.285156 7.808594-7.8125 20.472656-7.8125 28.28125 0l12.949219 12.949219 42.769531-42.769531c7.808594-7.808594 20.472656-7.808594 28.28125 0 7.8125 7.8125 7.8125 20.476562 0 28.285156l-56.90625 56.910156c-7.8125 7.808594-20.476563 7.808594-28.285156 0zm154.140625-15.507812c0-11.046875 8.953125-20 20-20h160c11.046875 0 20 8.953125 20 20s-8.953125 20-20 20h-160c-11.046875 0-20-8.953125-20-20zm0 0" /></svg>
)
const Client_Icon = () => (
    <svg className='client' version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
        viewBox="0 0 512 512" enable-background='new 0 0 512 512'>
        <g>
            <g>
                <path d="M495.984,252.588c-17.119-14.109-44.177-15.319-61.936,3.74l-44.087,47.327c-5.7-18.319-22.809-31.658-42.977-31.658
			h-78.675c-5.97,0-7.969-2.28-18.339-10.269c-39.538-34.468-98.924-34.358-138.342,0.33l-28.918,25.458
			c-12.999-6.88-28.178-7.05-41.248-0.52L8.294,303.575c-7.41,3.71-10.409,12.719-6.71,20.129l89.995,179.989
			c3.71,7.41,12.719,10.409,20.129,6.71l33.168-16.589c16.349-8.169,25.448-24.849,24.858-41.827h177.249
			c32.868,0,64.276-15.699,83.995-41.997l72.006-96.014C516.953,295.366,514.743,268.077,495.984,252.588z M131.456,466.985
			l-19.749,9.879L35.122,323.704l19.759-9.879c7.41-3.7,16.409-0.71,20.119,6.71l63.166,126.332
			C141.866,454.276,138.866,463.275,131.456,466.985z M478.985,295.976L406.98,391.99c-14.089,18.789-36.518,29.998-59.996,29.998
			H159.265l-56.207-112.423l28.388-24.988c28.248-24.849,70.846-24.849,99.094,0c16.639,14.649,26.988,17.419,37.768,17.419h78.675
			c8.27,0,14.999,6.73,14.999,14.999s-6.73,14.999-14.999,14.999h-76.605c-8.28,0-14.999,6.72-14.999,14.999
			s6.72,14.999,14.999,14.999h86.655c12.449,0,24.449-5.22,32.928-14.329l66.036-70.886c6.04-6.48,15.299-5.94,20.979-0.97
			C482.915,281.006,483.556,289.896,478.985,295.976z"/>
            </g>
        </g>
        <g>
            <g>
                <path d="M315.385,102.367c10.269-10.769,16.599-25.328,16.599-41.358c0-33.018-26.678-60.996-59.996-60.996
			c-33.068,0-60.996,27.928-60.996,60.996c0,15.539,6.09,30.208,17.149,41.478c-27.428,15.379-47.147,44.897-47.147,79.515v14.999
			c0,8.279,6.72,14.999,14.999,14.999h150.991c8.279,0,14.999-6.72,14.999-14.999v-14.999
			C361.982,148.064,343.315,118.086,315.385,102.367z M271.988,30.012c16.259,0,29.998,14.199,29.998,30.998
			c0,16.539-13.459,29.998-29.998,29.998c-16.799,0-30.998-13.739-30.998-29.998C240.99,44.501,255.479,30.012,271.988,30.012z
			 M210.992,182.002c0-33.068,27.928-60.996,60.996-60.996c33.078,0,59.996,27.358,59.996,60.996H210.992z"/>
            </g>
        </g>
    </svg>
)
const Clients_Icon = () => (
    <svg className='clients' enable-background="new 0 0 512 512" viewBox="0 0 512 512" xmlns="http://www.w3.org/2000/svg"><g><path d="m256 207c47.972 0 87-39.028 87-87s-39.028-87-87-87-87 39.028-87 87 39.028 87 87 87zm0-144c31.43 0 57 25.57 57 57s-25.57 57-57 57-57-25.57-57-57 25.57-57 57-57z" /><path d="m432 207c30.327 0 55-24.673 55-55s-24.673-55-55-55-55 24.673-55 55 24.673 55 55 55zm0-80c13.785 0 25 11.215 25 25s-11.215 25-25 25-25-11.215-25-25 11.215-25 25-25z" /><path d="m444.1 241h-23.2c-27.339 0-50.939 16.152-61.693 39.352-22.141-24.17-53.944-39.352-89.228-39.352h-27.957c-35.284 0-67.087 15.182-89.228 39.352-10.755-23.2-34.355-39.352-61.694-39.352h-23.2c-37.44 0-67.9 30.276-67.9 67.49v109.21c0 16.156 13.194 29.3 29.412 29.3h91.727c1.538 17.9 16.59 32 34.883 32h199.957c18.292 0 33.344-14.1 34.883-32h90.679c16.796 0 30.46-13.61 30.46-30.34v-108.17c-.001-37.214-30.461-67.49-67.901-67.49zm-414.1 67.49c0-20.672 17.002-37.49 37.9-37.49h23.2c20.898 0 37.9 16.818 37.9 37.49v10.271c-10.087 26.264-8 42.004-8 98.239h-91zm331 135.489c0 2.769-2.252 5.021-5.021 5.021h-199.958c-2.769 0-5.021-2.253-5.021-5.021v-81.957c0-50.19 40.832-91.022 91.021-91.022h27.957c50.19 0 91.022 40.832 91.022 91.021zm121-27.319c0 .517 5.592.34-91 .34 0-56.651 2.071-72.018-8-98.239v-10.271c0-20.672 17.002-37.49 37.9-37.49h23.2c20.898 0 37.9 16.818 37.9 37.49z" /><path d="m80 207c30.327 0 55-24.673 55-55s-24.673-55-55-55-55 24.673-55 55 24.673 55 55 55zm0-80c13.785 0 25 11.215 25 25s-11.215 25-25 25-25-11.215-25-25 11.215-25 25-25z" /></g></svg>
)
const Template_Icon = () => (
    <svg className="template" version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
        viewBox="0 0 507.312 507.312" style={{ enableBackground: 'new 0 0 507.312 507.312' }}>
        <g>
            <g>
                <g>
                    <polygon points="59.312,89.376 22.624,52.688 0,75.312 59.312,134.624 166.624,27.312 144,4.688 			" />
                    <polygon points="59.312,265.376 22.624,228.688 0,251.312 59.312,310.624 166.624,203.312 144,180.688 			" />
                    <polygon points="59.312,457.376 22.624,420.688 0,443.312 59.312,502.624 166.624,395.312 144,372.688 			" />
                    <rect x="411.312" y="416" width="32" height="32" />
                    <rect x="475.312" y="416" width="32" height="32" />
                    <rect x="219.312" y="416" width="160" height="32" />
                    <rect x="411.312" y="224" width="32" height="32" />
                    <rect x="475.312" y="224" width="32" height="32" />
                    <rect x="219.312" y="224" width="160" height="32" />
                    <rect x="475.312" y="64" width="32" height="32" />
                    <rect x="411.312" y="64" width="32" height="32" />
                    <rect x="219.312" y="64" width="160" height="32" />
                </g>
            </g>
        </g>
    </svg>
)
const Plugin_Icon = () => (
    <svg className="plugin" version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
        viewBox="0 0 512 512" style={{ enableBackground: 'new 0 0 512 512' }}>
        <g>
            <g>
                <path d="M448.801,271H497c8.284,0,15-6.716,15-15V111.4c0-8.284-6.716-15-15-15H367.4V63.2c0-34.849-28.352-63.2-63.2-63.2
			S241,28.352,241,63.2v33.2H111.4c-8.284,0-15,6.716-15,15V241H63.2C28.352,241,0,269.352,0,304.2s28.352,63.2,63.2,63.2h33.2V497
			c0,8.284,6.716,15,15,15H256c8.284,0,15-6.716,15-15v-48.2c0-18.307,14.894-33.2,33.2-33.2c18.306,0,33.2,14.894,33.2,33.2V497
			c0,8.284,6.716,15,15,15H497c8.284,0,15-6.716,15-15V352.4c0-8.284-6.716-15-15-15h-48.199c-18.308,0-33.201-14.894-33.201-33.2
			C415.6,285.894,430.493,271,448.801,271z M448.801,367.4H482V482H367.4v-33.2c0-34.849-28.352-63.2-63.2-63.2
			S241,413.951,241,448.8V482H126.4V352.4c0-8.284-6.716-15-15-15H63.2c-18.307,0-33.2-14.894-33.2-33.2
			c0-18.306,14.894-33.2,33.2-33.2h48.2c8.284,0,15-6.716,15-15V126.4H256c8.284,0,15-6.716,15-15V63.2
			c0-18.307,14.894-33.2,33.2-33.2c18.306,0,33.2,14.894,33.2,33.2v48.2c0,8.284,6.716,15,15,15H482V241h-33.199
			c-34.85,0-63.201,28.352-63.201,63.2S413.951,367.4,448.801,367.4z"/>
            </g>
        </g>
    </svg>
)
const Checking_Icon = () => (
    <svg className='checking' enable-background="new 0 0 24 24" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path d="m.638 13.173c-.304.354-.452.807-.417 1.273.036.466.251.891.606 1.194l7.403 6.346v.001c.321.273.719.421 1.136.421.052 0 .104-.003.156-.007.472-.042.898-.266 1.199-.632l12.665-15.411c.613-.746.504-1.852-.242-2.464l-2.318-1.904c-.744-.612-1.848-.504-2.463.24l-9.584 11.665-3.722-3.189c-.732-.627-1.839-.543-2.467.189zm3.444-1.329 4.303 3.688c.153.131.348.196.554.178.201-.018.386-.115.514-.271l10.07-12.255c.087-.107.246-.123.352-.035l2.318 1.904c.107.088.123.246.035.353l-12.664 15.41c-.058.07-.132.087-.171.09-.039.006-.115.001-.185-.059l-7.404-6.346c-.068-.059-.083-.132-.086-.171-.003-.038.001-.113.06-.182l1.952-2.278c.089-.102.247-.116.352-.026z" /></svg>
)
const Setting_Icon = () => (
    <svg className='setting' version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px"
        viewBox="0 0 512 512" style={{ enableBackground: 'new 0 0 512 512' }}>
        <g>
            <g>
                <path d="M496.455,90.786c-2.099-4.395-6.2-7.496-10.999-8.319c-4.8-0.82-9.7,0.734-13.143,4.178L386.5,172.462l-46.953-46.953
			l85.814-85.815c3.443-3.443,5.001-8.344,4.177-13.142c-0.824-4.8-3.925-8.9-8.319-10.999C399.917,5.377,376.121,0,352.402,0
			c-42.626,0-82.701,16.599-112.841,46.738c-45.197,45.197-58.838,113.031-35.485,171.813L18.522,404.109
			c-0.067,0.066-0.132,0.134-0.197,0.201C6.512,416.224,0.01,432.012,0.01,448.8c0,16.881,6.574,32.752,18.512,44.689
			C30.459,505.425,46.329,512,63.21,512c16.881,0,32.752-6.574,44.688-18.511l185.565-185.565
			c18.662,7.386,38.842,11.257,58.966,11.258c0.003,0,0.005,0,0.008,0c42.622,0,82.693-16.599,112.832-46.738
			C513.016,224.698,525.548,151.695,496.455,90.786z M444.057,251.23c-24.475,24.475-57.015,37.953-91.626,37.951
			c-19.274-0.001-38.599-4.365-55.887-12.622c-5.738-2.742-12.577-1.566-17.071,2.929L86.686,472.275
			c-6.271,6.271-14.607,9.724-23.476,9.724c-8.868,0-17.205-3.453-23.476-9.724c-6.271-6.271-9.725-14.608-9.725-23.476
			c0-8.867,3.454-17.204,9.726-23.477c0.059-0.059,0.117-0.117,0.174-0.177l192.607-192.612c4.495-4.495,5.668-11.335,2.929-17.071
			C211.821,166.003,222,106.723,260.772,67.95C285.248,43.478,317.789,30,352.402,30c11.92,0,23.861,1.67,35.328,4.897
			l-80.003,80.005c-5.858,5.857-5.858,15.355,0,21.213l68.166,68.167c2.813,2.814,6.628,4.394,10.606,4.394
			c3.979,0,7.794-1.58,10.607-4.394l80.023-80.027C489.73,168.84,477.584,217.704,444.057,251.23z"/>
            </g>
        </g>
    </svg>
)
const Files_Icon = () => (
    <svg className="files" id="Capa_1" enable-background="new 0 0 520 520" viewBox="0 0 520 520" xmlns="http://www.w3.org/2000/svg"><path d="m481.734 100.063h-158.331l-43.111-70.397c-2.727-4.452-7.571-7.166-12.792-7.166h-119.235c-21.099 0-38.265 17.166-38.265 38.266v65.51h-71.734c-21.1-.001-38.266 17.165-38.266 38.265v294.693c0 21.1 17.166 38.266 38.266 38.266h333.469c21.1 0 38.266-17.166 38.266-38.266v-65.51h71.734c21.1 0 38.266-17.166 38.266-38.266v-217.13c-.001-21.099-17.167-38.265-38.267-38.265zm-101.734 359.171c0 4.558-3.708 8.266-8.266 8.266h-333.468c-4.558 0-8.266-3.708-8.266-8.266v-294.693c0-4.558 3.708-8.266 8.266-8.266h71.734v199.184c0 3.297.419 6.498 1.207 9.552 4.254 16.493 19.256 28.714 37.058 28.714h231.735zm110-103.775c0 4.558-3.708 8.266-8.266 8.266h-86.734-246.734c-4.558 0-8.266-3.708-8.266-8.266v-214.184-80.51c0-4.558 3.708-8.266 8.265-8.266h110.832l43.111 70.397c2.727 4.452 7.571 7.166 12.792 7.166h166.734c4.558 0 8.266 3.708 8.266 8.266z" /></svg>
)
const File_Icon = () => (
    <svg className='file' id="Capa_1" enable-background="new 0 0 512 512" viewBox="0 0 512 512" xmlns="http://www.w3.org/2000/svg"><g><path d="m137.551 0-79.116 79.117v432.883h395.131v-512zm8.174 34.253v53.037h-53.037zm277.84 447.747h-335.13v-364.71h87.29v-87.29h247.841v452z" /><path d="m124.242 223.558v152.175l131.788 76.087 131.789-76.088v-152.174l-131.789-76.088zm218.576 8.66-86.789 50.106-86.788-50.106 86.788-50.107zm-188.576 25.98 86.788 50.106v100.215l-86.788-50.107zm116.787 150.322v-100.215l86.789-50.107v100.214z" /></g></svg>
)
const Object_Icon = () => (
    <HomeWorkOutlinedIcon className='object' />
)

//экспорт иконок для дерева
export const TreeIcons = new Map();
TreeIcons.set("Clients", Clients_Icon)
TreeIcons.set("Client", Client_Icon)
TreeIcons.set("Object", Object_Icon)
TreeIcons.set("Stage", Stage_Icon)
TreeIcons.set("Templates", Templates_Icon)
TreeIcons.set("Template", Template_Icon)
TreeIcons.set("Plugin", Plugin_Icon)
TreeIcons.set("Checking", Checking_Icon)
TreeIcons.set("Setting", Setting_Icon)
TreeIcons.set("Files", Files_Icon)
TreeIcons.set("File", File_Icon)

export const TreeDictionary = new Map();
TreeDictionary.set("Clients", "Заказчики")
TreeDictionary.set("Client", "Заказчик")
TreeDictionary.set("Object", "Объект")
TreeDictionary.set("Stage", "Стадия")
TreeDictionary.set("Templates", "Шаблоны")
TreeDictionary.set("Template", "Шаблон")
TreeDictionary.set("Plugin", "Плагин")
TreeDictionary.set("Checking", "Проверки")
TreeDictionary.set("Setting", "Настройки")
TreeDictionary.set("Files", "Файлы")
TreeDictionary.set("File", "Файл")

