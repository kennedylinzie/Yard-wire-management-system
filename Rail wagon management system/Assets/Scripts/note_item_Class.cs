using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class note_item_Class : MonoBehaviour
{

    public TMP_InputField _planned_activities;
    public TMP_InputField _active_loco;
    public TMP_InputField _wagon_plan;
    public TMP_InputField _achieved_activities;
    public TMP_InputField _loco;
    public TMP_InputField _wagon;
    public TMP_InputField _time_plan;
    public TMP_InputField _time_real_in;
    public TMP_InputField _time_out_finish;
    public TMP_InputField _status;
    public TMP_InputField _comments;
   

    public string planned_activities;
    public string active_loco;
    public string wagon_plan;
    public string achieved_activities;
    public string loco;
    public string wagon;
    public string time_plan;
    public string time_real_in;
    public string time_out_finish;
    public string status;
    public string comments;
    public string position;


    public void set_Note(string planned_activities_, string active_loco_, string wagon_plan_, string achieved_activities_
            , string loco_, string wagon_, string time_plan_, string time_real_in_, string time_out_finish_, string status_
            , string comments_,string pos_)
        {
           this.planned_activities = planned_activities_;
        this.active_loco = active_loco_;
        this.wagon_plan = wagon_plan_;
        this.achieved_activities = achieved_activities_;
        this.loco = loco_;
        this.wagon = wagon_;
        this.time_plan = time_plan_;
        this.time_real_in = time_real_in_;
        this.time_out_finish = time_out_finish_;
        this.status = status_;
        this.comments = comments_;
        this.position = pos_;

        _planned_activities.text = planned_activities_;
        _active_loco.text = active_loco_;
        _wagon_plan.text = wagon_plan_;
        _achieved_activities.text = achieved_activities_;
        _loco.text = loco_;
        _wagon.text = wagon_;
        _time_plan.text = time_plan_;
        _time_real_in.text = time_real_in_;
        _time_out_finish.text = time_out_finish_;
        _status.text = status_;
        _comments.text = comments_;

    }
    private void Start()
    {
        Command.Instance.get_references();
        position = this.gameObject.name;
        //this.gameObject.transform.wi
       // Invoke("CallMeWithWait", 2f);
    }

  

    public void Detete_note()
    {

        //Debug.Log(this.gameObject.name);
        Command.Instance.perf_code.Delete_note(this.gameObject.name);
    
    }

    void CallMeWithWait()
    {
        
    }

    public void Text_changed_work() 
    {

        planned_activities = _planned_activities.text;
        active_loco = _active_loco.text;
        wagon_plan = _wagon_plan.text;
        achieved_activities = _achieved_activities.text;
        loco = _loco.text;
        wagon = _wagon.text;
        time_plan = _time_plan.text;
        time_real_in = _time_real_in.text;
        time_out_finish = _time_out_finish.text;
        status = _status.text;
        comments = _comments.text;

        Update_time();
    }

    public void Update_time()
    {
        
        Command.Instance.perf_code.modify_home(planned_activities, active_loco, wagon_plan, achieved_activities,loco,wagon,
            time_plan, time_real_in, time_out_finish,status,comments,position); 
       // Debug.Log("vrooooooooooooooooooooooooom");
    }





}
