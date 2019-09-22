using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using space;

namespace space
{
    public class Controllor : MonoBehaviour, ISceneController, IUserAction
    {
        public LandModel start_land;            //开始陆地
        public LandModel end_land;              //结束陆地
        public BoatModel boat;                  //船
        private RoleModel[] roles;              //角色
        UserGUI user_gui;

        void Start()
        {
            SSDirector director = SSDirector.GetInstance();      //得到导演实例
            director.CurrentScenceController = this;             //设置当前场景控制器
            user_gui = gameObject.AddComponent<UserGUI>() as UserGUI;  //添加UserGUI脚本作为组件
            LoadResources();                                     //加载资源
        }

        //创建水，陆地，角色，船
        //移动船
        //移动角色
        //重新开始游戏
        //检测游戏是否结束
    }

}