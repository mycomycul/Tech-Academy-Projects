//For use in a modal that diaplys a list of items.
//Called on Modal load to reduce page load time.
//post is the id of the post for which dynamically made comments are created

function HideLastComments(post) {
    var postTarget = ("current-comments-" + post);      
    var hideMe = document.getElementById(postTarget).getElementsByTagName("td");
    var i;
    for (i = 5; i < hideMe.length; i++) {          
        hideMe[i].style.display = "none";
    }
    $(postTarget).animate({ scrollTop: 0 }, 'slow'); 
}
//On Clicking Show comments button
function ToggleLastComments(post) {
    var postTarget = ("current-comments-" + post);
    var moreTarget = (postTarget + "-more");
    var x = document.getElementById(postTarget).getElementsByTagName("td");
    var moreClick = document.getElementById(moreTarget); 
    var i;
    for (i = 5; i < x.length; i++) {
        if (x[i].style.display == "none") {
            x[i].style.display = "flex";
            moreClick.innerHTML = "Less Comments";
        }
        else { x[i].style.display = "none"; 
            moreClick.innerHTML = "More Comments";
        }
    }

}