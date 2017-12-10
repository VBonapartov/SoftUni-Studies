<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
//        $repo = $this->getDoctrine()->getRepository(Task::class);
//        $tasksOpen = $repo->findBy(["status" => "Open"]);
//        $tasksOpen = $repo->findBy(["status" => "In Progress"]);
//        $tasksOpen = $repo->findBy(["status" => "Finished"]);

        $tasks = $this->getDoctrine()->getRepository(Task::class)->findAll();

        return $this->render('task/index.html.twig', [
            'openTasks' => array_filter($tasks, function($value){return ($value->getStatus() === "Open");}),
            'inProgressTasks' => array_filter($tasks, function($value){return ($value->getStatus() === "In Progress");}),
            'finishedTasks' => array_filter($tasks, function($value){return ($value->getStatus() === "Finished");}),
        ]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $task = new Task();
        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);

        if($form->isSubmitted() && $form->isValid()) {
            if($task->getTitle() == null || $task->getStatus() == null) {
                return $this->redirectToRoute('create');
            }

            $em = $this->getDoctrine()->getManager();
            $em->persist($task);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render("task/create.html.twig",
            [
                'form' => $form->createView()
            ]
        );
    }

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $task = $this->getDoctrine()->getRepository(Task::class)->find($id);

        if($task == null) {
            return $this->redirectToRoute('index');
        }

        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);

        if($form->isSubmitted() && $form->isValid()) {
            $em = $this->getDoctrine()->getManager();
            $em->merge($task);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render("task/edit.html.twig",
            [
                'form' => $form->createView(),
                'task' => $task
            ]);
    }
}
